# dotnet publish
# docker build -t nventi/coreweb:x.x bin/Debug/netcoreapp1.0/publish/
# docker run -d -P 5000:5000 nventi/coreweb:x.x
# docker ps -a
# docker logs

FROM microsoft/dotnet:latest

COPY bin/Debug/netcoreapp1.0/publish /publish/

ENV ASPNETCORE_URLS http://*:80
EXPOSE 80

ENTRYPOINT dotnet /publish/CoreWeb1.dll
