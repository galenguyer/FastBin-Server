#!/usr/bin/env bash
# build, tag, and push docker images

# exit if a command fails
set -o errexit

# exit if required variables aren't set
set -o nounset

cd FastBin-Server
docker build -f Dockerfile -t fastbin-server:latest ..
