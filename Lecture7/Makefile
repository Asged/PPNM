CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

Out.Erf.gnuplot.svg : Out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set xlabel "x" ;\
		set ylabel "Erf(x)" ;\
		set grid ;\
		set title "Errorfunction" ;\
		plot \
			"Out.txt" with lines lc "red" notitle \
	'|tee log.gpi | gnuplot


Out.Gamma.gnuplot.svg : Out2.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "Out.Gamma.gnuplot.svg" ;\
		set xlabel "x" ;\
		set ylabel "Erf(x)" ;\
		set grid ;\
		set title "Errorfunction" ;\
		plot \
			"Out2.txt" with lines lc "red" notitle \
	'|tee log2.gpi | gnuplot

sfuns.dll : sfuns.cs ;$(MKLIB)
main.exe : main.cs sfuns.dll; $(MKEXE)
main2.exe : main2.cs sfuns.dll
	mcs -target:exe -out:main2.exe
Out.txt : main.exe
	mono $< > $@
Out2.txt : main2.exe
	mono main2.exe > Out2.txt

clean: 
	$(RM) *.exe *.dll [Oo]ut*  [Ll]og*
