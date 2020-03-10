#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-customer
WORKDIR /source
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out/customer
FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /app
COPY --from=build-customer /source/out/customer ./
ENTRYPOINT ["dotnet", "customer-services.dll"]