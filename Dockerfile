FROM mcr.microsoft.com/dotnet/sdk:3.1
LABEL maintainer="GraphLinq <info@graphlinq.io>"
ADD docker_build/ App/
EXPOSE 1337
WORKDIR /App
ENTRYPOINT ["dotnet", "NodeBlock.CLI.dll"]