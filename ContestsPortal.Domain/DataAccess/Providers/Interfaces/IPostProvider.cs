﻿using ContestsPortal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestsPortal.Domain.DataAccess.Providers.Interfaces
{
    public interface IPostProvider
    {
        IList<Post> GetAllPosts();

        Post GetPost(int postId);
    }
}
