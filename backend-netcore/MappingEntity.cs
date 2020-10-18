using AutoMapper;
using Happy.Models;
using Happy.Views;

namespace Happy
{
    public class MappingEntity : Profile  
    {  
        public MappingEntity()  
        {
            CreateMap<Orphanage, OrphanageView>();
        }  
    }  
}