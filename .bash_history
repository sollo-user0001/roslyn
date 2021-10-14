#!/bin/bash
set -Eeuo pipefail
cd "$(dirname "$BASH_SOURCE")"
versions=( "$@" )
if [ ${#versions[@]} -eq 0 ]; then 	versions=( */ ); fi
versions=( "${versions[@]%/}" )
arch="$(< arch)"
#!/bin/bash
CURRENT_VERSION=$(node -e "console.log(require('./package.json').dependencies['@lhci/server'])")
NEXT_VERSION=$(yarn info @lhci/server | grep 'latest:' -A 1 | tail -n 1 | grep -o "'.*'" | sed s/\'//g)
if [[ "$CURRENT_VERSION" == "$NEXT_VERSION" ]]; then   echo "Version is already at $NEXT_VERSION, exiting...";   exit 0; fi
