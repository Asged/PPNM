out.txt: main.exe
	mono main.exe > out.txt

library.dll: roots.cs
	mcs -target:library -out:library.dll roots.cs

main.exe: main.cs library.dll
	mcs -target:exe -out:main.exe -reference:library.dll main.cs

clean:
	rm -f *.dll *.exe Errorfunc.txt out.txt