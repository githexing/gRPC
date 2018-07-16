protoc.exe -I Grpc Grpc --csharp_out Grpc Grpc/proto/mainservice.proto --grpc_out Grpc --plugin=protoc-gen-grpc=grpc_csharp_plugin.exe

protoc.exe -I Grpc Grpc --csharp_out Grpc Grpc/proto/channelpushlogmessage.proto --grpc_out Grpc --plugin=protoc-gen-grpc=grpc_csharp_plugin.exe

protoc.exe -I Grpc Grpc --csharp_out Grpc Grpc/proto/channelpushtaskmessage.proto --grpc_out Grpc --plugin=protoc-gen-grpc=grpc_csharp_plugin.exe

protoc.exe -I Grpc Grpc --csharp_out Grpc Grpc/proto/commons.proto --grpc_out Grpc --plugin=protoc-gen-grpc=grpc_csharp_plugin.exe

protoc.exe -I Grpc Grpc --csharp_out Grpc Grpc/proto/stationedagentmessage.proto --grpc_out Grpc --plugin=protoc-gen-grpc=grpc_csharp_plugin.exe
