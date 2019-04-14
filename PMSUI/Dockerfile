FROM node:8.15.1

RUN mkdir  /usr/src/app

WORKDIR /usr/src/app

EXPOSE 4200
RUN npm install -g @angular/cli@7.3.3

COPY . /usr/src/app

CMD ng serve --host 0.0.0.0 --port 4200
