out.txt: main.exe
	mono main.exe > out.txt

library.dll: mc.cs vector.cs
	mcs -target:library -out:library.dll mc.cs vector.cs

main.exe: main.cs library.dll
	mcs -target:exe -out:main.exe -reference:library.dll main.cs

data.svg : data.txt Makefile
	echo "\
		set terminal svg background 'white' ;\
		set out '$@' ;\
		set xlabel 'N' ;\
		set ylabel 'Error in integral' ;\
		set yrange [0:0.2] ;\
		set grid ;\
		set title 'Uncertainty' ;\
		plot 'data.txt' using 1:3 with points lc rgb 'purple' title 'Relative uncertainty', 'data.txt' using 1:4 with points lt 7 lc rgb 'green' title 'Actual error' ;\
	" | tee log.gpi | gnuplot

clean:
	rm -f *.dll *.exe Errorfunc.txt *.svg *.txt