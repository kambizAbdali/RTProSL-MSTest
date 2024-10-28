using MSTestProject.ComponentHelper;
using OpenCvSharp;
using OpenQA.Selenium;
using RTProSL_MSTest.TestClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTProSL_MSTest.ComponentHelper
{
    public class ImageDetector : BaseClass
    {
        public ImageDetector(byte SliderNumber = 1)
        {
            this.SliderNumber = SliderNumber;
        }

        public void SetImageName(string ImageName)
        {
            this.ImageName = ImageName;
        }
        private byte SliderNumber = 1;
        private static string DetectedImagePath { set; get; }

        private double Accuracy = 0.15;

        private string ImageName = "BarcodeEquipmentImage.png";
        public By MouseHoverToSlider()
        {
            var locator = By.CssSelector(".width-image_slider"); //.width-image_slider

            var sliderElement = webElementAction.GetAllElementsByCssSelector(".width-image_slider")[SliderNumber - 1];
            for (int i = 0; i < 2; i++)
                webElementAction.MoveMouseToElement(sliderElement);
            return locator;
        }

        public void RemoveAllPicturesIfExist()
        {
            while (true)
            {
                ClickOnImageMoreOption();
                webElementAction.GetElementByCssSelector(".arrows-icon.icon-delete").Click();

                var removeOption = webElementAction.GetElementByXPath("//li[.='RemoveRemove']");
                var removeAriaDisabled = Convert.ToBoolean(removeOption.GetAttribute("aria-disabled"));
                if (removeAriaDisabled) break;
            }
        }

        public void AddPicture(string imageName = null)
        {
        tryToAddPicture:
            ClickOnImageMoreOption();
            try
            {
                var addPicElement = webElementAction.GetElementByCssSelector(".file-upload-button.ellipsis-content");
                addPicElement.Click();
            }
            catch
            {
                goto tryToAddPicture;
            }

            if (imageName != null) ImageName = imageName;
            Thread.Sleep(1000);
            DetectedImagePath = GenericHelper.SetFileInWindowUploader(ImageName);
        }

        public void ClickOnPrintBtn()
        {
            var printIcon = webElementAction.GetElementByCssSelector(".icon-print-image");
            printIcon.Click();
        }

        public void ClickOnImageSizeX5RedioButton()
        {
            var imageSizeX5 = webElementAction.GetElementById("imageSize-X5");
            imageSizeX5.Click();
        }

        public void ClickOnImageMoreOption()
        {
            for (int i = 0; i < 2; i++)
                MouseHoverToSlider();
            var ImageMoreOption = webElementAction.GetAllElementsByCssSelector("[data-section='formItem'][data-form-item-type='slider'] .icon-more-options")[SliderNumber - 1];
            ImageMoreOption.Click();
            Thread.Sleep(500);
        }

        public bool LocateImageInScreenshot(double accuracy = 0)
        {
            if (accuracy != 0) Accuracy = accuracy;
            string screenshotFileName = RandomValueGenerator.GenerateRandomString(20);
            Thread.Sleep(2000);
            var screenshotFilePath = GenericHelper.TakeScreenShot(screenshotFileName);
            Thread.Sleep(1000);
            // Load the screenshot image
            Mat screenshot = Cv2.ImRead(screenshotFilePath, ImreadModes.Color);

            // Load the image you want to detect
            Mat imageToDetect = Cv2.ImRead(DetectedImagePath, ImreadModes.Color);

            // Apply template matching to find the image in the screenshot
            Mat result = new Mat();
            Cv2.MatchTemplate(screenshot, imageToDetect, result, TemplateMatchModes.CCoeffNormed);

            // Get the location of the detected image
            double minVal, maxVal;
            Point minLoc, maxLoc;
            Cv2.MinMaxLoc(result, out minVal, out maxVal, out minLoc, out maxLoc);

            GenericHelper.DeleteScreenShotFile(screenshotFileName);

            // Check if the image is found in the screenshot
            if (maxVal > Accuracy)
            {
                Console.WriteLine("Image found in the screenshot. maxVal=" + maxVal);
                return true;
            }
            else
            {
                Console.WriteLine("Image not found in the screenshot. maxVal=" + maxVal);
                return false;
            }
        }

        public void EditPicture()
        {
        tryToEditPicture:
            ClickOnImageMoreOption();
            try
            {
                var editPicElement = webElementAction.GetElementByCssSelector(".arrows-icon.icon-edit");
                editPicElement.Click();
            }
            catch
            {
                goto tryToEditPicture;
            }
        }
    }
}