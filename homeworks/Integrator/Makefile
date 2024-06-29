out.txt: main.exe
	mono main.exe > out.txt

library.dll: integrator.cs
	mcs -target:library -out:library.dll integrator.cs

main.exe: main.cs library.dll
	mcs -target:exe -out:main.exe -reference:library.dll main.cs

errorfunc.svg : out.txt plots.txt Makefile
	echo "\
		set terminal svg background 'white' ;\
		set out '$@' ;\
		set xlabel 'x' ;\
		set ylabel 'rel' ;\
		set yrange [-2:2] ;\
		set grid ;\
		set title 'Errorfunction' ;\
		plot 'Errorfunc.txt' with lines lt 14 lc rgb 'purple' lw 5 title 'Errorfunction', 'plots.txt' with lines lt 7 lc rgb 'green' title 'Errorfunction from plots' ;\
	" | tee log.gpi | gnuplot

clean:
	rm -f *.dll *.exe *.svg *.txt