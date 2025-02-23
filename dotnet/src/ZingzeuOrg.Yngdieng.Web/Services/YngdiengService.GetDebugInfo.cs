﻿using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using YngdiengProtos = Yngdieng.Protos;
namespace ZingzeuOrg.Yngdieng.Web.Services
{
    public partial class YngdiengService : YngdiengProtos.YngdiengService.YngdiengServiceBase
    {

        public override Task<YngdiengProtos.DebugInfo> GetDebugInfo(YngdiengProtos.GetDebugInfoRequest request,
                                                     ServerCallContext context)
        {
            return Task.FromResult(new YngdiengProtos.DebugInfo { IndexVersion = _indexHolder.GetIndex().Version });
        }
    }
}
