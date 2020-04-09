export const ObjectFetch = function (target, source) {
  const newObject = {}
  Object.keys(target).forEach((key) => {
    if (source.hasOwnProperty(key)) {
      newObject[key] = source[key]
    } else {
      newObject[key] = target[key]
    }
  })
  return newObject
}

export const ObjectIsEmpty = function (obj) {
  for (var x in obj) { return false }
  return true
}
