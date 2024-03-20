FROM python:3.11

ENV FLASK_APP=chatai.py

WORKDIR /app

COPY . /app

RUN pip3 install --no-cache-dir -r requirements.txt

CMD ["flask", "run", "--host=0.0.0.0", "--port=8080"]