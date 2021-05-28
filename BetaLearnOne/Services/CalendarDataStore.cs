using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace BetaLearnOne.Services
{
   public class CalendarDataStore
    {
        CalendarEventCollection Eventcollection { get; set; } 


        public CalendarDataStore()
        {
            CalendarInlineEvent firstDefault = new CalendarInlineEvent()
            {
                Color = Color.Red,
                StartTime = DateTime.Now,
                EndTime = DateTime.Today,
                Subject = "Its Today",
                IsAllDay = true,

                
                
            };
            new CalendarEventCollection().Add(firstDefault);
           // Eventcollection.Add(firstDefault);
        }


      



       public void AddEvent(CalendarInlineEvent inlineEvent)
        {
            CalendarEventCollection collection = new CalendarEventCollection();
            Eventcollection = collection;
            Eventcollection.Clear();

            collection.Add(inlineEvent);

            Eventcollection = collection;


        }
        public void DeleteEvent(CalendarInlineEvent inlineEvent)
        {
            CalendarEventCollection collection = new CalendarEventCollection();
            Eventcollection = collection;
            Eventcollection.Clear();

            collection.Remove(inlineEvent);
            

            Eventcollection = collection;

        }

        public void ReLoadEvents()
        {
            CalendarEventCollection collection = new CalendarEventCollection();
            Eventcollection = collection;
            Eventcollection.Clear();

            Eventcollection = collection;

        }


        public CalendarEventCollection AccessEvents()
        {
            CalendarEventCollection collection = new CalendarEventCollection();
            collection = Eventcollection;
            return collection;

        }



    }
}
