﻿using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZingzeuOrg.Yngdieng.Web.Db;
using FrontendProtos = Yngdieng.Frontend.V3.Protos;

namespace ZingzeuOrg.Yngdieng.Web.Services.Frontend
{

    public partial class FrontendService : FrontendProtos.FrontendService.FrontendServiceBase
    {
        public async override Task<FrontendProtos.WordList> GetWordList(FrontendProtos.GetWordListRequest request,
                                                   ServerCallContext context)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "name must not be empty"));
            }
            var wordListId = ResourceNames.ToWordListId(request.Name);
            return Renderers.ToWordList(await _dbContext.WordLists.Where(w => w.WordListId == wordListId).SingleAsync());
        }
    }
}
