using AutoMapper;
using System;

namespace Core.Mappers
{
   public class TicksToDateTimeConverter : ITypeConverter<long, DateTime>
    {
        public DateTime Convert(long source, DateTime destination, ResolutionContext context)
        {
            return new DateTime(source);
        }
    }

}
