#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base-merchant
WORKDIR /app


COPY *.csproj ./
RUN dotnet restore

COPY . ./

RUN dotnet publish  -c Release -o /app


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS build
WORKDIR /app
COPY --from=base-merchant /app ./
ENTRYPOINT [ "dotnet", "MerchantServices.dll" ]