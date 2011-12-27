#!/usr/bin/sh
gconftool-2 -t str --set /desktop/gnome/background/picture_filename "$1"
