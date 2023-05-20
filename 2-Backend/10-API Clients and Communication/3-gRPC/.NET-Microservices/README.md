# Transfier command objects from platform Services to commands Service

## Server Service
1- install packages (Grpc.AspNetCore)
2- add protos schema file
3-   <ItemGroup>
		<Protobuf Include="Protos\platforms.proto" GrpcServices="server" />
	  </ItemGroup>
4-addGrpcPlatformService
5-use automapper to map from platform to GrpcPlatformModel
6-add DI of Grpc and mapGrpc endpoints in program file

## Client Service
1- add server url host in appsettings
2- install packages (Grpc.Tools,Grpc.Net.Client,Google.Protobuf)
3- add protos schema file
4-   <ItemGroup>
		<Protobuf Include="Protos\platforms.proto" GrpcServices="Client" />
	  </ItemGroup>
5-add PlatformDataCLient
6-use automapper to map from GrpcPlatformModel to Platform
7-add DI of PlatformDataCLient in program file
8-add PrpDb and add it in program file


