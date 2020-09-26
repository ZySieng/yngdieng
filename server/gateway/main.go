/*
Command example-gateway-server is an example reverse-proxy implementation
whose HTTP handler is generated by grpc-gateway.
*/
package main

import (
	"context"
	"flag"

	"github.com/golang/glog"
	"github.com/mindonglab/yngdieng/server/gateway/internal"
)

var (
	port       = flag.String("port", "8081", "HTTP port to listen on")
	endpoint   = flag.String("endpoint", "localhost:5002", "endpoint of the gRPC service")
	network    = flag.String("network", "tcp", `one of "tcp" or "unix". Must be consistent to -endpoint`)
	swaggerDir = flag.String("swagger_dir", "examples/internal/proto/examplepb", "path to the directory which contains swagger definitions")
)

func main() {
	flag.Parse()
	defer glog.Flush()

	ctx := context.Background()
	opts := internal.Options{
		Addr: ":" + *port,
		GRPCServer: internal.Endpoint{
			Network: *network,
			Addr:    *endpoint,
		},
		SwaggerDir: *swaggerDir,
	}
	if err := internal.Run(ctx, opts); err != nil {
		glog.Fatal(err)
	}
}
