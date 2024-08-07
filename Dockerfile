# Use the official .NET 8.0 SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG TARGETARCH
# Install Node.js from the official NodeSource repository (if required)
#RUN apt-get update && \
#    apt-get install -y curl && \
#    curl -fsSL https://deb.nodesource.com/setup_16.x | bash - && \
#    apt-get install -y nodejs

# Set the working directory inside the container
WORKDIR /app

# Copy the solution file
COPY MyProject.sln ./

# Copy the project files and restore dependencies
COPY MyProject/*.csproj MyProject/
COPY MyProject.Browser/*.csproj MyProject.Browser/
COPY MyProject.Simulator/*.csproj MyProject.Simulator/

RUN dotnet restore

# Copy the rest of the application files
COPY . .

#COPY MyProject.Browser/. .
RUN dotnet publish MyProject.Browser/MyProject.Browser.csproj -a $TARGETARCH --no-restore -o /app/build

# Stage 2: Node.js for dependencies (optional)
#FROM node:16 AS node

# Use a smaller runtime image for the final stage
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory inside the container
#WORKDIR /app

# Copy package.json and package-lock.json
#COPY package*.json ./

# Install dependencies
#RUN npm install

# Stage 2: Serve the app using Nginx
FROM nginx:alpine
COPY --from=build /app/build/wwwroot /usr/share/nginx/html

# Expose port 80 to be able to access the app
EXPOSE 80

# Set the entry point for the container to use Nginx
ENTRYPOINT ["nginx", "-g", "daemon off;"]