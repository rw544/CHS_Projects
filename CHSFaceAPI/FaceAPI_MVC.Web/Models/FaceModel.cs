using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CHSFaceAPI.Web.Models
{
    public class FaceModel
    {
        #region Fields

        private string age; //person age
        private string gender; //person gender 
        private string personName; //name of person
        private string facialHair; //person has hair or not
        private string smiling; //whether person is smiling or not
        private string glasses; //whether person has glasses
        private int faceHeight; //height of image pixel
        private int leftXPos; //top left face position X in pixel
        private int topYPos; //top left face position Y in pixel
        private int faceWidth; //width of face in pixel
        private string fileName; //name of image file
        private string filePath; //path of image file
        #endregion Fields

        #region Properties
        /// <summary>
        /// Gets or sets filename text string 
        /// </summary>
        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
            }
        }

        /// <summary>
        /// Gets or sets filePath text string 
        /// </summary>
        public string FilePath
        {
            get
            {
                return filePath;
            }

            set
            {
                filePath = value;
            }
        }

        /// <summary>
        /// Gets or sets gender text string 
        /// </summary>
        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        /// <summary>
        /// Gets or sets age text string
        /// </summary>
        public string Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

         /// <summary>
        /// Gets or sets image path
        /// </summary>
        public string ImagePath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets face id
        /// </summary>
        public string FaceId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets person's name
        /// </summary>
        public string PersonName
        {
            get
            {
                return personName;
            }

            set
           {
                personName = value;
            }
        }

        /// <summary>
        /// Gets or sets face height
        /// </summary>
        public int Height
        {
            get
            {
                return faceHeight;
            }

            set
            {
                faceHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets face position X
        /// </summary>
        public int Left
        {
            get
            {
                return leftXPos;
            }

            set
            {
                leftXPos = value;
            }
        }

        /// <summary>
        /// Gets or sets face position Y
        /// </summary>
        public int Top
        {
            get
            {
                return topYPos;
            }

            set
            {
                topYPos = value;
            }
        }

        /// <summary>
        /// Gets or sets face width
        /// </summary>
        public int Width
        {
            get
            {
                return faceWidth;
            }

            set
            {
                faceWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets facial hair display string
        /// </summary>
        public string FacialHair
        {
            get
            {
                return facialHair;
            }

            set
            {
                facialHair = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the face is smile or not
        /// </summary>
        public string IsSmiling
        {
            get
            {
                return smiling;
            }

            set
            {
                smiling = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the glasses type 
        /// </summary>
        public string Glasses
        {
            get
            {
                return glasses;
            }

            set
            {
                glasses = value;
            }
        }

        #endregion Properties

        
    }
}