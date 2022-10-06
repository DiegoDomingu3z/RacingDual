<template>
  <nav>
    <div class="row gx-0 img">
      <div class="col-md-4 mt-2"></div>
      <div class="col-md-4 text-center mt-3"><h1>DualRacing</h1></div>
      <div class="col-md-4 text-end mt-3"><Login /></div>
    </div>
    <div class="row gx-0">
      <div class="col-md-12">
        <div class="navbar-info">
          <div class="">
            <ul id="navbar" class="">
              <div class="dropdown">
                <li type="button" class="dropbtn p-3 rounded">F1</li>
                <div class="dropdown-content">
                  <a href="#">Link 1</a>
                  <a href="#">Link 2</a>
                  <a href="#">Link 3</a>
                </div>
              </div>
              <div class="dropdown">
                <div class="dropdown">
                  <li type="button" class="dropbtn">Gt Racing</li>
                  <div class="dropdown-content">
                    <a href="#">Link 1</a>
                    <a href="#">Link 2</a>
                    <a href="#">Link 3</a>
                  </div>
                </div>
              </div>
              <div class="dropdown">
                <div class="dropdown">
                  <li type="button" class="dropbtn">Indy Racing</li>
                  <div class="dropdown-content">
                    <a href="#">Link 1</a>
                    <a href="#">Link 2</a>
                    <a href="#">Link 3</a>
                  </div>
                </div>
              </div>
              <div class="dropdown">
                <div class="dropdown">
                  <li type="button" class="dropbtn">Nascar</li>
                  <div class="dropdown-content">
                    <a href="#">Link 1</a>
                    <a href="#">Link 2</a>
                    <a href="#">Link 3</a>
                  </div>
                </div>
              </div>
            </ul>
          </div>
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
  background-color: #ffffff;
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
  background-color: #616261;
  transition: 800ms;
  color: white;
}

.navbar-info {
  margin-top: 0.5em;
}

.img {
  background-image: url("../assets/img/freestock_1664404.gif");
  height: 10vh;
  width: 100%;
  background-position: center;
  background-size: cover;
}
</style>
