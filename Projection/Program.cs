using AutoMapper;
using System;
using System.Text.RegularExpressions;

namespace Projection
{
    /// <summary>
    /// Projection transforms a source to a destination beyond flattening the object model.  
    /// Without extra configuration, AutoMapper requires a flattened destination to match the source type's naming structure. 
    /// When we want to project source values into a destination that does not exactly match the source structure, 
    /// we must specify custom member mapping definitions.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {


            // Configure AutoMapper
            // Because the names of the destination properties do not exactly match the source property(`CalendarEvent.Date` would need to be `CalendarEventForm.EventDate`), we need to specify custom member mappings in our type map configuration:
            var configuration = new MapperConfiguration(cfg =>
              cfg.CreateMap<CalendarEvent, CalendarEventForm>()
                .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.Date.Date))
                .ForMember(dest => dest.EventHour, opt => opt.MapFrom(src => src.Date.Hour))
                .ForMember(dest => dest.EventMinute, opt => opt.MapFrom(src => src.Date.Minute)));
            var mapper = configuration.CreateMapper();

            // Model
            var calendarEvent = new CalendarEvent
            {
                Date = new DateTime(2008, 12, 15, 20, 30, 0),
                Title = "Company Holiday Party"
            };

            // Perform mapping
            CalendarEventForm form = mapper.Map<CalendarEvent, CalendarEventForm>(calendarEvent);
            if(form.EventDate.Equals(new DateTime(2008, 12, 15)) &&
                form.EventHour.Equals(20) &&
                form.EventMinute.Equals(30) &&
                form.Title.Equals("Company Holiday Party"))
            {
                Console.WriteLine("Projection succeeded!");
            }

        }
    }

    public class CalendarEvent
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
    }

    public class CalendarEventForm
    {
        public DateTime EventDate { get; set; }
        public int EventHour { get; set; }
        public int EventMinute { get; set; }
        public string Title { get; set; }
    }
}
