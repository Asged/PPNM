out.txt : main.exe
	mono main.exe > out.txt

main.exe : main.cs ODE.dll
	mcs -target:exe -out:main.exe -reference:ODE.dll main.cs

ODE.dll : ODE.cs vector.cs
	mcs -target:library -out:ODE.dll ODE.cs vector.cs

clean:
		rm -f *.dll *.exe [Oo]ut* *.svg *.png *.gpi

oscillator.svg : osc.txt osc2.txt Makefile
	echo "\
		set terminal svg background 'white' ;\
		set out '$@' ;\
		set xlabel 'x' ;\
		set ylabel 'rel' ;\
		set grid ;\
		set title 'Pendulum with friction' ;\
		plot 'osc.txt' lt 7 lc rgb 'purple' pointsize 1 notitle, 'osc2.txt' with lines lc 'blue' ;\
	" | tee log.gpi | gnuplot