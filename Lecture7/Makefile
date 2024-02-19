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
		set yrange [-5:5] ;\
		set xrange [-5:5] ;\
		plot \
			"$<" with lines lc "red" notitle \
			,0 with lines lt 2 lc "black" notitle ;\
	'|tee log.gpi | gnuplot

Out.txt : main.exe
	mono $< > $@

sfuns.dll : sfuns.cs ;$(MKLIB)
main.exe : main.cs sfuns.dll; $(MKEXE)

clean: 
	$(RM) *.exe *.dll [Oo]ut*  [Ll]og*
