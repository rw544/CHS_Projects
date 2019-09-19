using CHSFaceAPI.Web.Helper;
using CHSFaceAPI.Web.Models;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
//using Microsoft.Azure.CognitiveServices.Vision.Face;
//using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CHSFaceAPI.Web.Controllers
{
    public class FaceDetectionController : Controller
    {
        private static string ServiceKey = ConfigurationManager.AppSettings["FaceServiceKey"];
        private static string apiRoot = "https://centralus.api.cognitive.microsoft.com/face/v1.0"; //ConfigurationManager.AppSettings["CognitiveServicesFaceApiUrl"];

        private static string directory = "../UploadedFiles";
        private static string UplImageName = string.Empty;
        private ObservableCollection<FaceModel> _detectedFaces = new ObservableCollection<FaceModel>();
        private ObservableCollection<FaceModel> _resultCollection = new ObservableCollection<FaceModel>();
        public ObservableCollection<FaceModel> DetectedFaces
        {
            get
            {
                return _detectedFaces;
            }
        }
        public ObservableCollection<FaceModel> ResultCollection
        {
            get
            {
                return _resultCollection;
            }
        }
        public int MaxImageSize
        {
            get
            {
                return 450;
            }
        }

        // GET: FaceDetection
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveCandidateFiles()
        {
            string message = string.Empty, fileName = string.Empty, actualFileName = string.Empty; bool flag = false;
            //Requested File Collection
            HttpFileCollection fileRequested = System.Web.HttpContext.Current.Request.Files;
            if (fileRequested != null)
            {
                //Create New Folder
                CreateDirectory();

                //Clear Existing File in Folder
                ClearDirectory();

                for (int i = 0; i < fileRequested.Count; i++)
                {
                    var file = Request.Files[i];
                    actualFileName = file.FileName;
                    fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    int size = file.ContentLength;

                    try
                    {
                        file.SaveAs(Path.Combine(Server.MapPath(directory), fileName));
                        message = "File uploaded successfully";
                        UplImageName = fileName;
                        flag = true;
                    }
                    catch (Exception)
                    {
                        message = "File upload failed! Please try again";
                    }
                }
            }
            return new JsonResult
            {
                Data = new
                {
                    Message = message,
                    UplImageName = fileName,
                    Status = flag
                }
            };
        }

        [HttpGet]
        public async Task<dynamic> GetDetectedFaces()
        {
            ResultCollection.Clear();
            DetectedFaces.Clear();

            var DetectedResultsInText = string.Format("Detecting...");
            var imagePath = Server.MapPath(directory) + '/' + UplImageName as string;
            var QueryFaceImageUrl = directory + '/' + UplImageName;

            if (UplImageName != "")
            {
                //Create New Folder
                CreateDirectory();

                try
                {

                    // Call detection Azure REST API
                    using (var fileStream = System.IO.File.OpenRead(imagePath))
                    {
                        // get Image Details
                        var imageDetails = ImageHelper.GetImageDetails(imagePath);

                        //initiate FaceServiceClient by passing Azure FaceAPI subscriptin key and URI 
                        var faceServiceClient = new FaceServiceClient(ServiceKey,apiRoot);

                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                        //call FaceAPI's DetecAsync method to get facial feature
                        Face[] faces = await faceServiceClient.DetectAsync(fileStream, true, true, new FaceAttributeType[] { FaceAttributeType.FacialHair, FaceAttributeType.Gender, FaceAttributeType.Age, FaceAttributeType.Smile, FaceAttributeType.Glasses });
    
                        DetectedResultsInText = string.Format("{0} face(s) has been detected!!", faces.Length);
                        Bitmap CroppedFace = null;

                        foreach (var face in faces)
                        {
                            //Create & Save Cropped Images
                            var croppedImg = Convert.ToString(Guid.NewGuid()) + ".jpeg" as string;
                            var croppedImgPath = directory + '/' + croppedImg as string;
                            var croppedImgFullPath = Server.MapPath(directory) + '/' + croppedImg as string;
                            CroppedFace = CropBitmap(
                                            (Bitmap)Image.FromFile(imagePath),
                                            face.FaceRectangle.Left,
                                            face.FaceRectangle.Top,
                                            face.FaceRectangle.Width,
                                            face.FaceRectangle.Height);
                            CroppedFace.Save(croppedImgFullPath, ImageFormat.Jpeg);
                            if (CroppedFace != null)
                                ((IDisposable)CroppedFace).Dispose();

                            //load identified faces features into collection of FaceModel class
                            try
                            {
                                DetectedFaces.Add(new FaceModel()
                                {


                                    FacialHair = "black", // face.FaceAttributes.FacialHair.ToString(),
                                    FaceId = face.FaceId.ToString(),
                                    Gender = face.FaceAttributes.Gender,
                                    Age = string.Format("{0:#} years old", face.FaceAttributes.Age),
                                    IsSmiling = face.FaceAttributes.Smile > 0.0 ? "Smiling Face" : "Not Smiling Face",
                                    Glasses = face.FaceAttributes.Glasses.ToString(),
                                    FileName = croppedImg,
                                    FilePath = croppedImgPath,
                                    ImagePath = imagePath,
                                    Left = face.FaceRectangle.Left,
                                    Top = face.FaceRectangle.Top,
                                    Width = face.FaceRectangle.Width,
                                    Height = face.FaceRectangle.Height,
                                });
                            }
                            catch(Exception ex)
                            {
                                String s = ex.InnerException.ToString();
                            }
                        }

                        // Convert detection result into UI binding object for rendering
                        var rectFaces = ImageHelper.GetFaceImageRectangle(faces, MaxImageSize, imageDetails);
                        foreach (var face in rectFaces)
                        {
                            ResultCollection.Add(face);
                        }
                    }
                }
                catch (FaceAPIException ex)
                {
                    string s;
                    s = ex.ErrorMessage;
                    //do exception work
                }
            }
            return new JsonResult
            {
                Data = new
                {
                    QueryFaceImage = QueryFaceImageUrl,
                    MaxImageSize = MaxImageSize,
                    FaceInfo = DetectedFaces,
                    FaceRectangles = ResultCollection,
                    DetectedResults = DetectedResultsInText
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public Bitmap CropBitmap(Bitmap bitmap, int cropX, int cropY, int cropWidth, int cropHeight)
        {
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);
            return cropped;
        }

        public void CreateDirectory()
        {
            bool exists = System.IO.Directory.Exists(Server.MapPath(directory));
            if (!exists)
            {
                try
                {
                    Directory.CreateDirectory(Server.MapPath(directory));
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        public void ClearDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(Server.MapPath(directory)));
            var files = dir.GetFiles();
            if (files.Length > 0)
            {
                try
                {
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        fi.Delete();
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }
    }
}