using SurveyApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DAL
{
    public class SurveyAppContext : DbContext
    {
        public SurveyAppContext() : base("SurveyAppContext")
        {

        }

        public DbSet<Survey> Surveys { get; set; }
    }
}
