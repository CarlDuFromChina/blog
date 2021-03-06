using AutoMapper;
using Blog.Core.Module.DataService;
using Blog.Core.Pixabay;
using Blog.Core.Store;
using Blog.Core.Store.SysFile;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Profiles
{
    public class FileProfile : Profile, IProfile
    {
        public FileProfile()
        {
            CreateMap<sys_file, FileInfoModel>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(e => e.id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(e => e.name))
                .ForMember(dest => dest.downloadUrl, opt => opt.MapFrom(e => e.DownloadUrl));
        }
    }
}
