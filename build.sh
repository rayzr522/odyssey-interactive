#!/bin/bash

fail() {
    echo "$*" 1>&2
    exit 1
}

cd "$(dirname "$0")" || exit 1

cd website || fail "Failed to find website dir. (git clone https://github.com/Rayzr522/odyssey-interactive.git -b gh-pages website)"

echo "Cleaning up old build"
rm -rf TemplateData Build index.html || fail "Failed to remove old build data"

cd ../Odyssey-Interactive-Unity || fail "Failed to find Unity project"

echo "Running Unity build"
/opt/Unity/Editor/Unity -quit -batchmode -executeMethod WebGLBuilder.build || fail "Failed to build Unity project"

[[ -d webgl-build ]] || fail "Failed to locate webgl-build dir"

echo "Moving files to website folder"
mv webgl-build/* ../website
rm -rf webgl-build
cd ../website || fail "Failed to find website dir"

echo "Build complete"

echo "Pushing to GitHub..."
git add .
git commit -m "Rebuilt + deployed"

echo "Press CTRL+C to cancel, otherwise all changes will be pushed to GitHub"
read -r || exit 1

git push
