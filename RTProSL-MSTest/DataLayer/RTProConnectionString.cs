using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static log4net.Appender.ColoredConsoleAppender;

namespace RTProSL_MSTest.DataLayer
{
    public class RTProConnectionString
    {
        private string _database;
        public RTProConnectionString(string database)
        {
            _database = database;
        }

        public string Get()
        {
            return "Data Source=192.168.1.101;Initial Catalog=" + _database + ";User ID=rti2;Password=npg3";
        }
    }
}