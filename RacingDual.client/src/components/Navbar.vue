<template>
  <nav>
    <div class="row">
      <div class="col-6">hello</div>
      <div class="col-6">
        <div>
          <ul id="navbar">
            <div class="dropdown">
              <li type="button">F1</li>
              <div class="dropdown-content">
                <a href="#">Link 1</a>
                <a href="#">Link 2</a>
                <a href="#">Link 3</a>
              </div>
            </div>
            <li>Gt Racing</li>
            <li>Indy Racing</li>
            <li>Nascar</li>
            <li>Nascar</li>
          </ul>
        </div>
      </div>
    </div>
  </nav>
</template>

<script>
import { computed } from '@vue/runtime-core';
import Pop from '../utils/Pop';
import { AppState } from '../AppState';

export default {
  setup() {
    return {

    };

  },
};
</script>

<style scoped>
.info {
  justify-content: space-between;
}

ul#navbar {
  display: inline;
  /* Any other CSS you want */
}
ul#navbar li {
  display: inline;
}

li {
  cursor: pointer;
  margin-inline-end: 1em;
}

/* The container <div> - needed to position the dropdown content */
.dropdown {
  position: relative;
  display: inline-block;
}

/* Dropdown Content (Hidden by Default) */
.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f1f1f1;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0, 0, 0, 0.2);
  z-index: 1;
}

/* Links inside the dropdown */
.dropdown-content a {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
}

/* Change color of dropdown links on hover */
.dropdown-content a:hover {
  background-color: #ddd;
}

/* Show the dropdown menu on hover */
.dropdown:hover .dropdown-content {
  display: block;
}

/* Change the background color of the dropdown button when the dropdown content is shown */
.dropdown:hover .dropbtn {
  background-color: #3e8e41;
}
</style>
