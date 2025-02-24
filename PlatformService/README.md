1. `docker build -t xmario/platformservice .`
2. `docker ps`
3. `docker stop <NAME>`
4. `docker run -p 8080:80 -d xmario/platformservice`
5. `docker push xmario/platformservice --all-tags`
6. `kubectl version`
7. `kubectl apply -f ./platform-depl.yaml`
8. `k get deployments`
9. `k delete -f ./platform-depl.yaml`
10. `k apply -f ./platform-depl.yaml -f ./platform-np-srv.yaml`
11. `k get services`
12. `k delete -f ./platform-depl.yaml -f ./platform-np-srv.yaml`
13. `kubectl logs platforms-depl-86f475c477-dkrw5`