CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
TIME = time --output=$@ --append --format "$$nthreads %e %U" 

Out.times.svg : out.times.txt
	echo '\
		set terminal svg background "white" ;\
		set out"$@" ;\
		set xlabel "number of threads" ;\
		set ylabel "real time" ;\
		plot "$<" with lp ;\
		'|tee log.gpi | gnuplot

N = 1e9
out.times.txt : main.exe Makefile
	>$@
	for nthreads in $$(seq 1 16); do\
		$(TIME) mono main.exe -nthreads:$$nthreads -nterms:$(N); \
	done

main.exe : main.cs; $(MKEXE)

test : out1 out2 out3 out4

out1 : main.exe ; mono $< -nthreads:1 -nterms:2e8 > $@
out2 : main.exe ; mono $< -nthreads:1 -nterms:2e8 > $@
out3 : main.exe ; mono $< -nthreads:1 -nterms:2e8 > $@
out4 : main.exe ; mono $< -nthreads:1 -nterms:2e8 > $@

clean :
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*
