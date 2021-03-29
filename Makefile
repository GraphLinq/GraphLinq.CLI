docker:
	rm -rf docker_build
	mkdir docker_build
	echo "Create plugin directory"
	mkdir docker_build/plugins
	cp -a bin/Release/netcoreapp3.1/. docker_build/
	docker build -t graphlinqcli .