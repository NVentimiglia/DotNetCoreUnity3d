#dotnet build
#dotnet publish
#cd bin/Debug/netcoreapp1.0/publish
#docker build -t nventi/coreweb:latest
#docker run -d -p 5000:5000 nventi/coreweb:latest
#docker ps

FROM microsoft/dotnet:latest

# Set the Working Directory
WORKDIR /app

# Configure the listening port
ENV ASPNETCORE_URLS http://*:80
EXPOSE 80

# Copy the app
COPY . /app

# Start the app
ENTRYPOINT dotnet CoreWeb1.dll
