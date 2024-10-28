using RTProSL_MSTest.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RTProSL_MSTest.DataLayer.RTProConnectionString;

namespace RTProSL_MSTest.DataLayer
{
    static class UpdateSetup
    {
        public static async Task SetUseDeprec(string value)
        {
            string query = "UPDATE setup SET UseDeprec = @UseDeprec";
            await UpdateSetupValue(query, new { UseDeprec = value });
        }

        public static async Task SetCheckLicensing(string value)
        {
            string query = "UPDATE setup SET CheckLicensing = @CheckLicensing";
            await UpdateSetupValue(query, new { CheckLicensing = value });
        }

        public static async Task SetAllowMultipleReservationOnBarcode(string value)
        {
            string query = "UPDATE setup SET AllowMultipleReservationOnBarcode = @AllowMultipleReservationOnBarcode";
            await UpdateSetupValue(query, new { AllowMultipleReservationOnBarcode = value });
        }

        private static async Task UpdateSetupValue(string query, object parameters)
        {
            var dbService = new DBService();
            RTProConnectionString connectionString = new RTProConnectionString(AppConfigKeys.DatabaseName);
            await dbService.UpdateAsync(connectionString.Get(), query, parameters);
        }
    }
}