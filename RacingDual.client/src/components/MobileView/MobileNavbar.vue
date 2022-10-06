<template>
  <div class="menu-wrap">
    <input type="checkbox" class="toggler" />
    <div class="hamburger">
      <div></div>
    </div>
    <div class="menu">
      <div>
        <div class="text-center">
          <ul>
            <li>Home</li>
            <li>About</li>
            <li>F1</li>

            <li>Nascar</li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.menu-wrap {
  position: fixed;
  top: 30px;
  left: 80px;
  z-index: 1;
  display: none;
}

.menu-wrap .toggler {
  position: absolute;
  top: 0px;
  right: 0;
  z-index: 2;
  cursor: pointer;
  width: 50px;
  height: 50px;
  opacity: 0;
}

.menu-wrap .hamburger {
  position: absolute;
  top: 0;
  right: 0;
  z-index: 1;
  width: 60px;
  height: 60px;
  padding: 1rem;
  background: var(--primary-color);
  display: flex;
  align-items: center;
  justify-content: center;
}

.menu-wrap .hamburger > div {
  position: relative;
  flex: none;
  width: 100%;
  height: 2px;
  z-index: 1;
  background: black;
  display: flex;
  align-items: center;
  justify-content: center;
  transition: all 0.4s ease;
}

.menu-wrap .hamburger > div::before,
.menu-wrap .hamburger > div::after {
  content: "";
  position: absolute;
  z-index: 1;
  top: -10px;
  width: 100%;
  height: 2px;
  background: inherit;
}

.menu-wrap .hamburger > div::after {
  top: 10px;
}

.menu-wrap .toggler:checked + .hamburger > div {
  transform: rotate(135deg);
}

.menu-wrap .toggler:checked + .hamburger > div:before,
.menu-wrap .toggler:checked + .hamburger > div:after {
  top: 0;
  transform: rotate(90deg);
}

.menu-wrap .toggler:checked:hover + .hamburger > div {
  transform: rotate(225deg);
}

.menu-wrap .toggler:checked ~ .menu {
  visibility: visible;
}

.menu-wrap .toggler:checked ~ .menu > div {
  transform: scale(1);
  transition-duration: 0.5s;
}

.menu-wrap .toggler:checked ~ .menu > div > div {
  opacity: 1;
  transition: opacity 0.4s ease 0.4s;
}

.menu-wrap .menu {
  position: fixed;
  top: 0;
  right: 0;
  width: 100%;
  height: 100%;
  z-index: 1;
  visibility: hidden;
  overflow: hidden;
  display: flex;
  align-items: center;
  justify-content: center;
}

.menu-wrap .menu > div {
  background: rgba(255, 255, 255, 0.9);
  //   border-radius: 50%;
  width: 200vw;
  height: 250vw;
  display: flex;
  flex: none;
  align-items: center;
  justify-content: center;
  transform: scale(0);
  transition: all 0.4s ease;
}

.menu-wrap .menu > div > div {
  text-align: center;
  max-width: 90vw;
  max-height: 100vh;
  opacity: 0;
  transition: opacity 0.4s ease;
}

.menu-wrap .menu > div > div > ul > li {
  list-style: none;
  color: white;
  font-size: 1.5rem;
  padding: 1rem;
}

.menu-wrap .menu > div > div > ul > li > a {
  color: inherit;
  text-decoration: none;
  transition: color 0.4s ease;
}

.menu-wrap {
  display: block;
}

.menu ul li {
  display: block !important;
}

.menu ul li a {
  color: black !important;
}

.menu-wrap .hamburger {
  z-index: 2;
}

.menu-wrap .toggler {
  z-index: 3;
}
</style>