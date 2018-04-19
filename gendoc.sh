git pull
cd /c/github/expression/docfx_project
docfx.exe
git add .
git commit . -m "update documentation"
cd /c/github/expression/docs
git add .
git commit . -m "update documentation"
cd /c/github/expression
git push
