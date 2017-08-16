using AutoMapper;
using SurveyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DAL
{
    public class SurveyRepository
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<SurveyData> GetAll()
        {
            using (var context = new SurveyAppContext())
            {
                var query = from s in context.Surveys
                            select new SurveyData
                            {
                                Id = s.Id,
                                Age = s.Age,
                                Answer1= s.Answer1,
                                Answer2 = s.Answer2,
                                Answer3 = s.Answer3,
                                Email = s.Email,
                                Gender = s.Gender
                            };
                return query.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SurveyData Get(int id)
        {
            return GetAll().Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id)
        {
            using (var context = new SurveyAppContext())
            {
                var obj = context.Surveys.SingleOrDefault(x => x.Id == id);
                if (obj != null)
                {
                    context.Surveys.Remove(obj);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public static void Persist(SurveyData item)
        {
            using (var context = new SurveyAppContext())
            {
                var obj = context.Surveys.FirstOrDefault(t => t.Id == item.Id) ?? new Survey();
                obj.Age = item.Age;
                obj.Answer1 = item.Answer1;
                obj.Answer2 = item.Answer2;
                obj.Answer3 = item.Answer3;
                obj.Email = item.Email;
                obj.Gender = item.Gender;
                if (obj.Id > 0)
                {
                    context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    context.Surveys.Add(obj);
                }
                context.SaveChanges();
                item.Id = obj.Id;
            }
        }
    }
}
