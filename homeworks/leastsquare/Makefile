out.txt: main.exe
	mono main.exe > out.txt

library.dll: matrix.cs vector.cs QRGS.cs leastsquares.cs
	mcs -target:library -out:library.dll matrix.cs vector.cs QRGS.cs leastsquares.cs

main.exe: main.cs library.dll
	mcs -target:exe -out:main.exe -reference:library.dll main.cs

rad.gnuplot.svg : radData.txt Makefile
	echo "\
		set terminal svg background 'white' ;\
		set out '$@' ;\
		set xlabel 'x' ;\
		set ylabel 'rel' ;\
		set grid ;\
		set title 'Errorfunction' ;\
		plot 'radData.txt' with yerrorbars lt 7 lc rgb 'purple' pointsize 1 notitle, exp(4.96 - 0.171*x) with lines lc 'blue' dashtype '--' ;\
	" | tee log.gpi | gnuplot





																																			
clean:
		rm -f *.dll *.exe [Oo]ut* *.svg *.png *.gpi

