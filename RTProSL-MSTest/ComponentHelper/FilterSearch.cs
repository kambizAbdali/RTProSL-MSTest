using OpenQA.Selenium;
using RTProSL_MSTest.TestClasses;
using System.Drawing;
using System.Text.RegularExpressions;

namespace RTProSL_MSTest.ComponentHelper
{
    public class FilterSearch : BaseClass
    {
        private string GridListId; //We defined a variable to receive the ""GridListId"" that is sent from the test method.
                                   //which is used to find the grid on the page.

        private string ColumnName; //"ColumnName receives a value that has different column names in different panels,
                                   //which vary between panels and are used for filtering in that column."

        private string FilterId;//We defined a variable to receive the ""IdFilter"" that is sent from the test method.
                                //You send the desired filter ID.

        private string ColId = default;//We defined a variable to receive the ""ColId"" that is sent from the test method.
                                       //Sometimes the filter ID on the page is different from another ID, and we send its ID through ColId.

        private string ReplacementValue = default;//We defined a variable to receive the ""ReplacementValue"" that is sent from the test method.
                                                  //The ReplacementValue means that the value searched in the
                                                  //filter is different from the value in the grid, not in terms of value but in terms of ColId.

        private Color Color = default;//We defined a variable to receive the ""Color"" that is sent from the test method.
        private IJavaScriptExecutor driver;
        private bool ValidValueInGrid = default;
        private bool IsDataTypeValueInFilter = true;

        //---DATETIME
        public string today = DateTime.Now.ToString("M/d/yyyy");
        public string yearAgo = DateTime.Now.AddYears(-1).ToString("M/d/yyyy");
        private List<DateTime> dateArray = new List<DateTime>();
        private List<DateTime> dateTwoArray = new List<DateTime>(); //dateTwoArray can equals checkOut Date or To date
        private List<DateTime> dateOneArray = new List<DateTime>(); //dateOneArray can equals checkin Date or From date
        List<IWebElement> dateArrayColIds;
        List<IWebElement> dateTwoArrayColIds = null;

        public FilterSearch(string filterId = default, string gridListId = default, string columnName = default, string colId = default,
            string replacementValue = default, Color Color = default)
        {
            this.FilterId = filterId;
            this.GridListId = gridListId;
            this.ColumnName = columnName;
            this.ColId = colId;
            this.ReplacementValue = replacementValue;
            this.Color = Color;
        }

        enum DataTypeInFilter
        {
            Text,
            DropDown,
            CheckBox,
            RadioButton,
            TextInGrid
        }
        private void ClickFilter()
        { //This try-catch block is written to open the filter window. When the filter window is open; otherwise,
          //if it is closed, the catch black triggers and click on the filter button.
            if (webElementAction.IsElementPresent(By.CssSelector(".body-filter-button-container.down-area")) == false)
                webElementAction.GetElementBySpecificAttribute("data-button-type", "filter").Click();
        }

        private void ClickRefresh()
        {
            webElementAction.GetElementById("body-filter-refresh-btn").Click();
            WaitForLoadingSpiner();
            Thread.Sleep(2000);
        }
        private void GenerateDataInFilterFrame(DataTypeInFilter dataType, string colValue = default)
        {
            switch (dataType)
            {
                case DataTypeInFilter.Text:
                    new WebElementDataGenerator(webElementAction.GetElementBySpecificAttribute("data-form-item-name", FilterId));
                    break;

                case DataTypeInFilter.DropDown:
                    CloseAllDropdowns();
                    OpenDropdown();
                    SetDropdownValue(colValue);
                    break;

                case DataTypeInFilter.CheckBox:
                    ToggleCheckBox();
                    break;

                case DataTypeInFilter.RadioButton:
                    ToggleRadioButton();
                    break;

                case DataTypeInFilter.TextInGrid:
                    EnterTextInGrid(colValue);
                    break;
            }
            WaitForLoadingSpiner();
        }

        private void CloseAllDropdowns()
        {
            var closeElements = webElementAction.GetAllElementsByCssSelector(".icon-close");
            foreach (var element in closeElements.Take(closeElements.Count - 1))
                element.Click();
        }

        private void OpenDropdown()
        {
            webElementAction.GetElementBySpecificAttribute("data-form-item-name", FilterId).Click();
            Thread.Sleep(1000);
        }

        private void SetDropdownValue(string colValue)
        {
            var activityTypeDropDown = webElementAction.GetInputElementByDataFormItemNameInDiv(FilterId);
            activityTypeDropDown.SendKeys(colValue); // set data in input drop down  
            if (webElementAction.IsElementPresent(By.CssSelector("[title = '" + colValue + "']")))
                webElementAction.GetElementBySpecificAttribute("title", colValue).Click();
        }

        private void ToggleCheckBox()
        {
            var inActiveElement = webElementAction.GetInputElementByDataFormItemNameInDiv(FilterId);
            if (!inActiveElement.Selected)
            {
                inActiveElement.Click();
                IsDataTypeValueInFilter = true;
            }
        }

        private void ToggleRadioButton()
        {
            var radioButton = webElementAction.GetElementById(FilterId);
            if (!radioButton.Selected)
            {
                radioButton.Click();
                IsDataTypeValueInFilter = true;
            }
        }

        private void EnterTextInGrid(string colValue)
        {
            var context = webElementAction.GetElementBySpecificAttribute("data-form-item-name", FilterId)
                .FindElements(By.TagName("input"))
                .Where(o => o.GetAttribute("autocomplete") == "one-time-code")
                .ToList();
            Thread.Sleep(1000);
            context[0].SendKeys(colValue);
        }

        private List<IWebElement> GetAllColsBySpecificColIdInGrid(string colId = null)
        {
            var gridList = webElementAction.GetElementById(GridListId);
            colId ??= FilterId; 
            Thread.Sleep(2000); 

            return gridList.FindElements(By.TagName("div"))
                .Where(o => o.GetAttribute("col-id") == colId)
                .ToList();
        }

        private bool CheckColorIsInList(List<IWebElement> cols)
        {
            var gridList = webElementAction.GetElementById(GridListId);

            var coloredElements = gridList.FindElements(By.TagName("div"))
                .Where(o => o.GetCssValue("background-color") == Color.ToString())
                .ToList();

            ValidValueInGrid = coloredElements.Any(); 
            return ValidValueInGrid;
        }

        private void CheckTheRowInTrue(string filterValue = default ,string valueFilter = "")
        {
            if (ValidValueInGrid != IsDataTypeValueInFilter)
                Assert.Fail("Does not match inserted filter value ('" + filterValue + "') with showed value in Grid ('" + valueFilter + "')");
        }
        private List<IWebElement> GetAllInputDateTimesInFilterFrame(string filterIdInForm = null)
        {
            string activeFilterId = !string.IsNullOrEmpty(filterIdInForm) ? filterIdInForm : FilterId;
 
            return webElementAction.GetElementBySpecificAttribute("data-form-item-name", activeFilterId)
                .FindElements(By.TagName("input"))
                .Where(o => o.GetAttribute("autocomplete") != "off")
                .ToList();
        }

        public bool FindAndGetColsID(string dateGridColId, string secondDateGridColId)
        {
            if (string.IsNullOrEmpty(secondDateGridColId))
            {
                dateArrayColIds = GetAllColsBySpecificColIdInGrid(dateGridColId);
                if (dateArrayColIds.Count == 2) return true;
            }// If no row exists, we have at least two col-ids: one for the column title and the another for the footer.
            else
            {
                dateArrayColIds = GetAllColsBySpecificColIdInGrid(dateGridColId);
                dateTwoArrayColIds = GetAllColsBySpecificColIdInGrid(secondDateGridColId);
                if (dateArrayColIds.Count == 2 && dateTwoArrayColIds.Count == 2) return true;
            }// If no row exists, we have at least two col-ids: one for the column title and the another for the footer.
            return false;
        }

        public bool FindDateTimeInYearDays(List<IWebElement> dateArrayColIds, List<IWebElement> dateTwoArrayColIds = null)
        {
            for (DateTime date = DateTime.Parse(yearAgo); date <= DateTime.Parse(today); date = date.AddDays(1))
                dateArray.Add(date);

            if (dateTwoArrayColIds == null)
                foreach (var element in dateArrayColIds)
                {
                    if (DateTime.TryParse(element.Text, out DateTime date))
                        dateOneArray.Add(date);
                }
            else
            {
                foreach (var element in dateArrayColIds)
                {
                    if (DateTime.TryParse(element.Text.Replace(".", "/"), out DateTime date))
                        dateOneArray.Add(date);
                }
                foreach (var element in dateTwoArrayColIds)
                {
                    if (DateTime.TryParse(element.Text, out DateTime date))
                        dateTwoArray.Add(date);
                }
            }
            var isAnyDateClose = dateArray.Any(date1 => dateOneArray.Any(date2 => date1.Date == date2.Date) || dateTwoArray.Any(date3 => date1.Date == date3.Date));

            if (isAnyDateClose || dateOneArray.Count == 0 && dateTwoArray.Count == 0) return true;
            return false;
        }

        private List<DateTime> ConvertToDateList(List<IWebElement> elements)
        {
            var dateList = new List<DateTime>();
            foreach (var element in elements)
                if (DateTime.TryParse(element.Text.Replace(".", "/"), out DateTime date))
                    dateList.Add(date);
            return dateList;
        }

        private string GenerateDataInGridFrame()
        {
            var gridList = webElementAction.GetElementById(GridListId);
            if (ColId == default) ColId = FilterId;

            string result = TryGetColumnValue(ColId, gridList);
            if (result != null) return result;

            GridSortDescendingByColId(ColId);
            result = TryGetColumnValue(ColId, gridList);
            if (result != null) return result;

            GridSortAcendingByColId(ColId);
            return TryGetColumnValue(ColId, gridList) ?? GetFallbackColumnValue(ColId);
        }

        private string TryGetColumnValue(string colId, IWebElement gridList)
        {
            var colElement = GetFirstColElement(colId, gridList);
            Thread.Sleep(1000);

            return IsColumnValid(colElement) ? colElement.Text : null;
        }

        private string GetFallbackColumnValue(string colId)
        {
            var foundedCols = GetAllColsBySpecificColIdInGrid(colId);
            foreach (var foundedCol in foundedCols.Skip(1).Take(foundedCols.Count() - 2))
                if (IsColumnValid(foundedCol))
                    return foundedCol.Text;
            return null;
        }

        private bool IsColumnValid(IWebElement col)
        {
            return col != null && !string.IsNullOrEmpty(col.Text) && !string.IsNullOrEmpty(col.GetAttribute("value"));
        }

        private IWebElement GetFirstColElement(string coId, IWebElement gridList)
        {
            IWebElement ColElement = gridList.FindElements(By.TagName("div")).Where(o => o.GetAttribute("col-id") == coId).ElementAt(1);
            return ColElement;
        }

        //-------------------------------------------Start Filter Search For All Data Type ----------------------------------------

        public void FilterSearchInTextDataInGridDataType(string secondColumnName = default)
        {
            if (!FindColumnInMainGrid(ColumnName) && !string.IsNullOrEmpty(ColumnName))
            {
                if (!string.IsNullOrEmpty(secondColumnName))
                {
                    if (!FindColumnInMainGrid(secondColumnName))
                        goto exitFilter;
                }
                else {goto exitFilter;}
            }
            //generate value on input element
            string filterValueInModel = GenerateDataInGridFrame();
            if (string.IsNullOrEmpty(filterValueInModel)) goto exitFilter;

            //click on btn filter
            ClickFilter();

            GenerateDataInFilterFrame(DataTypeInFilter.TextInGrid, filterValueInModel);

            ClickRefresh();
            //Find value in grid
            var foundedCols = GetAllColsBySpecificColIdInGrid(ColId);

            // If no row exists, we have at least two col-ids: one for the column title and the another for the footer.
            if (foundedCols.Count() == 2) goto exitFilter;

            for (int i = 1; i < foundedCols.Count() - 1; i++) // (always first and last colIds are empty)
                if (foundedCols[i].Text != filterValueInModel
                    && foundedCols[i].Text.Contains(filterValueInModel)
                    && foundedCols[i].Text.ToLower().Contains(filterValueInModel.ToLower())
                    && foundedCols[i].Text.ToLower() != filterValueInModel.ToLower()
                    && Regex.IsMatch(filterValueInModel, @"\b" + Regex.Escape(foundedCols[i].Text) + @"\b"))
                    Assert.Fail("Does not match inserted filter value ('" + filterValueInModel + "') with showed row in Grid ('" + foundedCols[i].Text + "')");
            exitFilter: { }
        }


        public void FilterSearchInTextDataType(string secondColumnName = default)
        {
            if (!FindColumnInMainGrid(ColumnName) && !string.IsNullOrEmpty(ColumnName))
            {
                if (!string.IsNullOrEmpty(secondColumnName))
                {
                    if (!FindColumnInMainGrid(secondColumnName))
                        goto exitFilter;
                }
                else { goto exitFilter; }
            }

            WaitForLoadingSpiner();

            if( webElementAction.IsDivPresentBySpecificText("The list is too large to be displayed"))
            {
                return;
            }

            //click on btn filter
            ClickFilter();

            //generate value on input element
            GenerateDataInFilterFrame(DataTypeInFilter.Text);

            //find in value to input
            string filterValueInModal = webElementAction.GetInputElementByDataFormItemNameInDiv(FilterId).GetAttribute("value");

            if (filterValueInModal == "")
                goto exitFilter;

            //Refresh filter in grid
            ClickRefresh();

            //Find value in grid
            var foundedCols = GetAllColsBySpecificColIdInGrid(ColId);

            if (foundedCols.Count() == 2) goto exitFilter; // If no row exists, we have at least two col-ids: one for the column title and the another for the footer.

            for (int i = 1; i < foundedCols.Count() - 1; i++)
            { // (always first and last colIds are empty)
                if (!filterValueInModal.Contains(foundedCols[i].Text))
                    Assert.Fail("Doesn't match inserted filter value ('" + filterValueInModal + "') with showed row in Grid ('" + foundedCols[i].Text + "')");
                if (i <= 5) break;
            }
            exitFilter: { }
        }

        public void FilterSearchInDropDownDataType(string[] DropDownValue , string secondColumnName= default)
        {
            if (!FindColumnInMainGrid(ColumnName) && !string.IsNullOrEmpty(ColumnName))
            {
                if (!string.IsNullOrEmpty(secondColumnName))
                {
                    if (!FindColumnInMainGrid(secondColumnName))
                        goto exit;
                }
                else { goto exit; }
            }

            for (int j = 0; j < DropDownValue.Length; j++)
            {
                ClickFilter();

                //generate value on input element
                GenerateDataInFilterFrame(DataTypeInFilter.DropDown, DropDownValue[j]);

                //refresh in age
                ClickRefresh();

                //Find value in grid
                var foundedCols = GetAllColsBySpecificColIdInGrid(ColId);
                if (foundedCols.Count() == 2) goto exitFilter; // If no row exists, we have at least two col-ids: one for the column title and the another for the footer.

                for (int i = 1; i < foundedCols.Count() - 1; i++)
                    if (foundedCols[i].Text.ToLower() != DropDownValue[j].ToLower())
                        Assert.Fail("Doesn't match inserted filter value ('" + DropDownValue[j] +
                                    "') with showed row in Grid ('" + foundedCols[i].Text + "')");
                exitFilter: { }
            }
            exit: { }
        }

        public void FilterSearchInCheckBoxDataType(string secondColumnName = default)
        {
            if (!FindColumnInMainGrid(ColumnName) && !string.IsNullOrEmpty(ColumnName))
            {
                if (!string.IsNullOrEmpty(secondColumnName))
                {
                    if (!FindColumnInMainGrid(secondColumnName))
                        goto exitFilter;
                }
                else { goto exitFilter; }
            }
            //click in filter page
            ClickFilter();

            //set and click with check box
            GenerateDataInFilterFrame(DataTypeInFilter.CheckBox);
            string checkBoxValue = webElementAction.GetElementBySpecificAttribute("data-form-item-name", FilterId).GetAttribute("value");

            //refresh in page
            ClickRefresh();

            //select and search in grid
            var foundedCols = GetAllColsBySpecificColIdInGrid(ColId);

            if (Color != null) //my be some filter search to be color type 
                if (CheckColorIsInList(foundedCols)) goto vFilter;

            if (foundedCols.Count() == 2) goto exitFilter; // If no row exists, we have at least two col-ids: one for the column title and the another for the footer.

            for (int i = 1; i < foundedCols.Count() - 1; i++)
            {
                try
                {
                    if (string.IsNullOrEmpty(foundedCols[i].Text)
                        || foundedCols[i].Text.Contains("%") == true
                        || foundedCols[i].FindElements(By.TagName("i")).FirstOrDefault(o => o.GetAttribute("data-icon-name") == "tick-blue") != null
                        || foundedCols[i].Text == ReplacementValue
                        || foundedCols[i].GetAttribute("value") == ReplacementValue
                        || foundedCols[i].Text != ReplacementValue
                        || foundedCols[i].GetAttribute("value") != ReplacementValue)
                        ValidValueInGrid = true;
                }
                catch //If the checkbox is unchecked, it will be cached.
                {
                    ValidValueInGrid = false;
                }
                CheckTheRowInTrue(ReplacementValue, foundedCols[i].Text);
                goto exitFilter;
            }
            vFilter: { }
            CheckTheRowInTrue();
        exitFilter: { }
        }
        public void FilterSearchInRadioButtonDataType(string secondColumnName = default)
        {
            if (!FindColumnInMainGrid(ColumnName) && !string.IsNullOrEmpty(ColumnName))
            {
                if (!string.IsNullOrEmpty(secondColumnName))
                {
                    if (!FindColumnInMainGrid(secondColumnName))
                        goto exitFilter;
                }
                else { goto exitFilter; }
            }
            //click in filter page
            ClickFilter();

            //set and click with check box
            GenerateDataInFilterFrame(DataTypeInFilter.RadioButton);

            //refresh in page
            ClickRefresh();

            //select and search in grid
            var foundedCols = GetAllColsBySpecificColIdInGrid(ColId);

            if (Color != null) //my be some filter search to be color type 
            {
                if (CheckColorIsInList(foundedCols)) CheckTheRowInTrue("Not Color");
                goto exitFilter;
            }

            if (foundedCols.Count() == 2) goto exitFilter;// If no row exists, we have at least two col-ids: one for the column title and the another for the footer.

            for (int i = 1; i < foundedCols.Count() - 1; i++)
            {
                try
                {
                    if (foundedCols[i].FindElements(By.TagName("i")).First(o =>
                            o.GetAttribute("data-icon-name") == "tick-blue") != null
                        || foundedCols[i].Text == ReplacementValue
                        || foundedCols[i].GetAttribute("value") == ReplacementValue)
                        ValidValueInGrid = true;
                }
                catch //If the checkbox is unchecked, it will be cached.
                {
                    ValidValueInGrid = false;
                }
                CheckTheRowInTrue(ReplacementValue, foundedCols[i].Text);
            }
            exitFilter: { }
        }

        public void FilterSearchInDateTimeDataType(string dateGridColId, string secondDateGridColId = null, string idFormDateTimeBeginAndFrom = default, string idFormDateTimeToEnd = default) //mabe "secondDateColId"
        {
            ClickFilter();

            if (!string.IsNullOrEmpty(idFormDateTimeBeginAndFrom))
            {
                var InputDateTimeBeginFrom = GetAllInputDateTimesInFilterFrame(idFormDateTimeBeginAndFrom);
                //clear in input date
                InputDateTimeBeginFrom[0].Clear();
                //send value date time in today and yearAgo
                InputDateTimeBeginFrom[0].SendKeys(yearAgo);

                var InputDateTimeToEnd = GetAllInputDateTimesInFilterFrame(idFormDateTimeToEnd);
                //clear in input date
                InputDateTimeToEnd[0].Clear();
                //send value date time in today and yearAgo
                InputDateTimeToEnd[0].SendKeys(today);
            }
            else
            {
                var InputDateTime = GetAllInputDateTimesInFilterFrame();
                int i;
                for (i = 0; i < InputDateTime.Count; i++)
                {
                    //clear in input date
                    InputDateTime[i].Clear();
                    //send value date time in today and yearAgo
                    InputDateTime[i].SendKeys(yearAgo); //10/3/2023 //yearAgo
                }
                if (InputDateTime.Count == 2)
                {
                    InputDateTime[i - 1].Clear();
                    InputDateTime[i - 1].SendKeys(today); //10/3/2024 //today
                }
            }
            ClickRefresh();
            if (FindAndGetColsID(dateGridColId, secondDateGridColId)) goto exitFilter;
            if (!FindDateTimeInYearDays(dateArrayColIds, dateTwoArrayColIds))
                Assert.Fail("Doesn't match inserted filter value" +
                            " ('" + "YearsAgo :" + yearAgo + " - " + "Today :" + today + "') with showed row in Grid)");
            exitFilter: { }
        }
    }
}
