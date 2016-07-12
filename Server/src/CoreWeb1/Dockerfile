# dotnet publish
# docker build -t nventi/coreweb:1.8 bin/Debug/netcoreapp1.0/publish/
# docker run -d -P nventi/coreweb:1.8
# docker ps -a
# docker logs <key>


FROM microsoft/dotnet:latest

ADD . /app

WORKDIR /app

ENV ASPNETCORE_URLS http://*:80
EXPOSE 80

ENTRYPOINT dotnet CoreWeb1.dll
