FROM node:12 as node

EXPOSE 80
EXPOSE 443

RUN mkdir app
COPY framework-challenge /app
WORKDIR /app
RUN npm install -g @angular/cli@v9-lts
RUN npm install
RUN ng build

##### Stage 2
FROM nginx:alpine
VOLUME /var/cache/nginx
COPY --from=node /app/nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=node /app/dist/framework-challenge /usr/share/nginx/html