#!/usr/bin/sh
xfconf-query -c xfce4-desktop -p /backdrop/screen0/monitor0/image-path -s "$1"
