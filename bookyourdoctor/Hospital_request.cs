//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
namespace bookyourdoctor
{
    namespace bookyourdoctor
    {


        public partial class Hospital_request
        {
            public FINALSCRIPTTEntities1 db = new FINALSCRIPTTEntities1();
            public System.TimeSpan Hospital_time { get; set; }
            public System.DateTime date { get; set; }
            public string is_request { get; set; }
            public string patient_name { get; set; }
            public string Hospital_day { get; set; }
            public string Request_Status { get; set; }
            public string doctor_id { get; set; }

            public List<DateTime> timeslots(String doctorid)
            {
                var ide = db.doctor_scedule.Where(p => (p.doctor_id == doctorid));

                DateTime clockin = ide.First().hospital_start_time;
                DateTime clockout = ide.First().hospital_end_time;

                var hours = new List<DateTime>();
                hours.Add(clockin);

                var next = new DateTime(clockin.Year, clockin.Month, clockin.Day,
                                        clockin.Hour, 0, 0, clockin.Kind);

                while ((next = next.AddHours(1)) < clockout)
                {
                    hours.Add(next);
                }
                hours.Add(clockout);
                return hours;
            }
            public static IEnumerable<SelectListItem> slots(String doctorid)
            {
                IList<SelectListItem> items = new List<SelectListItem>();
                Hospital_request hr = new Hospital_request();
                List<DateTime> dt = hr.timeslots(doctorid);
                foreach (DateTime item in dt)
                {
                    items.Add(new SelectListItem { Text = item.Hour.ToString(), Value = item.Hour.ToString() });
                }
                return items;

            }
        }
    }
}
