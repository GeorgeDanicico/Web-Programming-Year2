<?php
  $user = 'root';
  $pass = '';
  $db = 'vacations';

  $conn = new mysqli('localhost', $user, $pass, $db) or die("unable to connect to database");
  echo 'connect </br>';

  $id = (int) $_POST["id"];
  $city = $_POST["city"];
  $country = $_POST["country"];
  $description = $_POST["description"];
  $tourists = $_POST["tourists"];
  $cost = (int) $_POST["estimated_cost"];

  $sql = "INSERT INTO destinations 
    (id, city, country, descriptions, tourists_target, estimated_cost)
    VALUES
    ($id, '$city', '$country', '$description', '$tourists', $cost)
  ";

  if ($conn->query($sql) === TRUE) {
    echo "New destination added successfully";
  } else {
    echo "Error: " . $sql . "<br>" . $conn->error;
  }

  $conn->close();
?>