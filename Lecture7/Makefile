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
			"$<" with lines lc "red" notitle \
	'|tee log.gpi | gnuplot

Out.Gamma.gnuplot.svg : Out.txt Makefile
	echo '\
		plot \
			"$<" with lines lc "red" notitle \
	'|tee log.gpi | gnuplot
Out.txt : main.exe
	mono $< > $@

Out2.txt : main2.exe
	mono $< > $@

sfuns.dll : sfuns.cs ;$(MKLIB)
main.exe : main.cs sfuns.dll; $(MKEXE)
main2.exe : main2.cs sfuns.dll; $(MKEXE)

clean: 
	$(RM) *.exe *.dll [Oo]ut*  [Ll]og*
