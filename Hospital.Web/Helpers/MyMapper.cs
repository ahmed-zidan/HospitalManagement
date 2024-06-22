using AutoMapper;
using Hospital.Core;
using Hospital.Web.Areas.Admin.Dtos;
using Hospital.Web.Areas.Admin.DTOS;

namespace Hospital.Web.Helpers
{
    public class MyMapper:Profile
    {
        public MyMapper()
        {
            CreateMap<HospitalInfo, HospitalInfoDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
               
            
        }
    }
}
