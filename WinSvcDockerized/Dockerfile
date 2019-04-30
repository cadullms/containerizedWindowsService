# escape=`
# based on https://github.com/Microsoft/iis-docker/blob/master/windowsservercore-1709/Dockerfile

FROM microsoft/windowsservercore:1709

RUN powershell -Command `
    Invoke-WebRequest -UseBasicParsing -Uri """https://dotnetbinaries.blob.core.windows.net/servicemonitor/2.0.1.3/ServiceMonitor.exe""" -OutFile """C:\ServiceMonitor.exe"""

WORKDIR C:\MyService

COPY bin\${buildconfig:-debug} .

RUN powershell -Command `
    New-Service -Name """myservice""" `
    -DisplayName """My breathtakingly awesome windows service""" `
    -BinaryPathName """C:\MyService\WinSvcDockerized.exe""" `
    -StartupType Automatic

EXPOSE 80

ENTRYPOINT ["C:\\ServiceMonitor.exe", "myservice"]