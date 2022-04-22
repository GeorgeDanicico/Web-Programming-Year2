<?php
  header('Access-Control-Allow-Headers: Access-Control-Allow-Origin, Content-Type');
  header('Access-Control-Allow-Origin: *');
  header('Content-Type: application/json, charset=utf-8');

  $user = 'root';
  $pass = '';
  $db = 'vacations';

  $conn = new mysqli('localhost', $user, $pass, $db) or die("unable to connect to database");
  echo 'connect </br>';

  $json = file_get_contents('php://input');
  $array = json_decode($json);

  $stmt = $conn->prepare('INSERT INTO destinations (id, city, country, descriptions, tourists_target, estimated_cost)
    VALUES (?, ?, ?, ?, ?, ?)');

  $stmt->bind_param('issssi', $array->id, $array->city, $array->country, 
  $array->description, $array->tourists, $array->estimated_cost);

  $stmt->execute();

  // $sql = "INSERT INTO destinations 
  //   (id, city, country, descriptions, tourists_target, estimated_cost)
  //   VALUES
  //   ($id, '$city', '$country', '$description', '$tourists', $cost)
  // ";

  $conn->close();
?>