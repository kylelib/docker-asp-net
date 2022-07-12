# docker-asp-net
ASP.Net Core application with Docker Linux support based on ASP.Net Tutorial

Contains two ASP.Net projects based on the Microsoft ASP.Net Weather Forecast tutorial
    - host-api - runs on Kestral and supplies the weather forecast data to requestors
    - conatiner-api - intendend to run in a Docker Linux container and call out to host-api

Requests from the container-api to host-api when running in docker must use the host.docker.internal DNS name in order to access the hosting computer's resources.

The host-api can run in Kestral, IIS Express or a Container. However container-api running in Docker would need additional setup to all to IIS Express or Docker hosted
endpoints.

Note regarding what works and what doesn't:

    docker -> kestrel         # works
    kestrel -> kestrel        # works
    docker -> iis express     # no go due to iis express isolation on localhost -- requires opening ports and tweaking config
    docker -> docker          # Not tested -- requires Docker network setup to communicate between containers
    kestrel -> docker         # Not tested -- expect it should work


Debugging notes:

For Debugging open the Container's CLI from Docker for Windows and install these utilities\
apt-get update					# This ensures your container is up to date\
apt-get install iputils-ping	# This gets you a ping utility inside your container\
apt-get install net-tools       # Gets you addional networking tools ** I couldn't get this to work\
apt-get install curl            # This installs curl for testing endpoints

Resources:\
Udemy training - Max's course

https://marcroussy.com/2020/09/01/dotnet-docker-networking/

https://tkit.dev/2020/03/07/accessing-localhost-net-core-webapi-from-a-docker-container/

https://blog.kloud.com.au/2017/02/27/remote-access-to-local-aspnet-core-apps-from-mobile-devices/


