FROM microsoft/dotnet:2.1-aspnetcore-runtime

RUN ln -s /lib/x86_64-linux-gnu/libdl-2.24.so /lib/x86_64-linux-gnu/libdl.so

#RUN echo "deb http://mirrors.aliyun.com/debian wheezy main contrib non-free \
#deb-src http://mirrors.aliyun.com/debian wheezy main contrib non-free \
#deb http://mirrors.aliyun.com/debian wheezy-updates main contrib non-free \
#deb-src http://mirrors.aliyun.com/debian wheezy-updates main contrib non-free \
#deb http://mirrors.aliyun.com/debian-security wheezy/updates main contrib non-free \
#deb-src http://mirrors.aliyun.com/debian-security wheezy/updates main contrib non-free" > /etc/apt/sources.list
#Asp.Net Core Docker操作系统已经从wheezy版本升级到stretch版本了，需要更换源
RUN echo "deb http://mirrors.aliyun.com/debian stretch main contrib non-free \
deb-src http://mirrors.aliyun.com/debian stretch main contrib non-free \
deb http://mirrors.aliyun.com/debian stretch-updates main contrib non-free \
deb-src http://mirrors.aliyun.com/debian stretch-updates main contrib non-free \
deb http://mirrors.aliyun.com/debian-security stretch/updates main contrib non-free \
deb-src http://mirrors.aliyun.com/debian-security stretch/updates main contrib non-free \
deb http://mirrors.aliyun.com/debian/ stretch-backports main non-free contrib \
deb-src http://mirrors.aliyun.com/debian/ stretch-backports main non-free contrib" > /etc/apt/sources.list

RUN apt-get update
RUN apt-get install libfontconfig1 -y
RUN apt-get install libgdiplus -y && ln -s libgdiplus.so gdiplus.dll

COPY ./fonts/msyh.ttc /usr/share/fonts/dejavu

WORKDIR /app
COPY . /app
EXPOSE 5000
ENTRYPOINT ["dotnet", "NetCoreDraw.dll"]
